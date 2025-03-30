using PhoneNumbers;
using System.Text.RegularExpressions;
using View;
namespace Model;

internal static class Validation {

    public enum StringValidationType {
        NAME,
        FORENAME,
        SURNAME,
        DESCRIPTION,
        DATE,
        PHONE,
        ADDRESS,
        DATE_FUTURE,
        DATE_PAST,
        QUANTITY,
        PRICE,
        STOCK_AMOUNT,
        FALSE,
        TRUE,
    }

    public static bool ValidateDateFuture(this string str, string str1) {
        if (!ValidateDate(str) || !ValidateDate(str1)) {
            return false;
        }

        var dt_future = Convert.ToDateTime(str);
        var dt_past = Convert.ToDateTime(str1);

        return dt_future > dt_past;
    }

    public static bool Validate(this string str, StringValidationType type) {
        return type switch {
            NAME => str.All(x => char.IsAsciiLetter(x) || char.IsWhiteSpace(x) || x == '-') && str.Length < 20 && !str.All(x => char.IsWhiteSpace(x)) && !char.IsWhiteSpace(str[0]),
            FORENAME => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 20 && !str.All(x => char.IsWhiteSpace(x)) && !char.IsWhiteSpace(str[0]),
            SURNAME => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 20 && !str.All(x => char.IsWhiteSpace(x)) && !char.IsWhiteSpace(str[0]),
            ADDRESS => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 50 && !str.All(x => char.IsWhiteSpace(x)) && !char.IsWhiteSpace(str[0]),
            DATE => ValidateDate(str),
            PHONE => ValidatePhone(str),
            PRICE => ValidatePrice(str),
            DESCRIPTION => str.Length < 100 && str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && !str.All(x => char.IsWhiteSpace(x)) && !char.IsWhiteSpace(str[0]),
            QUANTITY => ValidateQuantity(str),
            DATE_FUTURE => ValidateDateFuture(str),
            DATE_PAST => ValidateDatePast(str),
            STOCK_AMOUNT => ValidateStockAmount(str),
            FALSE => ValidateAlwaysFalse(),
            _ => true
        };
    }

    private static bool ValidateStockAmount(string str) {
        var form = (Master!.CurrentlyDisplayedForm as FormCreate);

        var val = form?.PropertyValues.FirstOrDefault(x => x.Name == "StockId");

        if (val is null) return false;

        if (val.Value() == "Choose") {
            return false;
        }

        var stock = DAL.Query<Stock>().First(x => x.Id == Convert.ToInt32(val.Value()));

        if (Int32.TryParse(str, out int i) && i <= stock.Amount && i > 0) {
            return true;
        }

        return false;
    }

    private static bool ValidatePhone(string str) {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        try {
            var phoneNumber = phoneUtil.Parse(str, "GB");
            return phoneUtil.IsValidNumber(phoneNumber);
        } catch (Exception) {
            return false;
        }
    }


    private static bool ValidatePrice(string str) {
        if (str.Length == 0) {
            return false;
        }

        if (str[0] == '$' || str[0] == '£') {
            str = str.Substring(1);
        }

        if (!decimal.TryParse(str, out decimal d) || d <= 0 || d > 500_000) {
            return false;
        }

        return Regex.IsMatch(str, @"^-?(\d+|\d{1,3}(?:\,\d{3})+)?(\.\d+)?$");
    }

    private static bool ValidateQuantity(string str) {
        if (str.Length == 0) {
            return false;
        }

        if (!int.TryParse(str, out int d) || d <= 0 || d >= 500) {
            return false;
        }

        return Regex.IsMatch(str, @"^-?(\d+|\d{1,3}(?:\,\d{3})+)?(\.\d+)?$");
    }

    private static bool ValidateAlwaysFalse() => false;

    private static bool ValidateDate(string str)
        => DateTime.TryParse(str, out DateTime _);

    private static bool ValidateDateFuture(string str) {
        if (!ValidateDate(str))
            return false;

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now <= dt) {
            return false;
        }

        return true;
    }

    private static bool ValidateDatePast(string str) {
        if (!ValidateDate(str)) {
            return false;
        }

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now >= dt)
            return false;

        return true;
    }

    public static string ValidationMessage(string name, string model_name) =>
        name switch {
            "Forename" => "Must be less than 20 characters",
            "Surname" => "Must be less than 20 characters",
            "Name" => "Must be less than 20 characters",
            "Description" => "Must be less than 50 characters",
            "ContactNumber" => "Must be a valid Phone Number",
            "Billing Address" => "Must be a valid address",
            "Address" => "Must be a valid address",
            "Price" => "Must be a valid number below £500_000, ($) and (£) are allowed",
            "Amount" => name == "TakeStock" ? $"Cannot be higher than the amount of stock" : "Must be a valid integer below 500",
            "Quantity" => "Must be a valid number below 500",
            "Date" => "Must be a valid date",
            "StartDate" => "Must be a date in the future",
            "EndDate" => "Must be a date the in the future, and after the StartDate",
            _ => "No validation message"
        };

    public static bool HasValidationMessage(string str) =>
        str switch {
            "Paid" => false,
            "StockId" => false,
            var a when a.Contains("Id") => false,
            _ => true,
        };
}

