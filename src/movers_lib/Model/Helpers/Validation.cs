namespace Model;


internal static class Validation {

    public enum StringValidationType {
        NAME,
        DATE,
        DATE_FUTURE,
        DATE_PAST,
    }

    public enum IntValidationType {
        PRICE,
        OTHER,
    }

    public static bool Validate(this string str, StringValidationType type) {
        return type switch {
            // May only have ascii letters and digits
            // And not longer than 20 digits
            NAME => str.Any(x => !char.IsAsciiLetterOrDigit(x)) && str.Length < 20,
            DATE => ValidateDate(str),
            DATE_FUTURE => ValidateDateFuture(str),
            DATE_PAST => ValidateDatePast(str),
            _ => true
        };
    }

    public static bool Validate(this int num, IntValidationType type) {
        return type switch {
            PRICE => num < 1_000_000 && num >= 0,
            _ => true
        };
    }

    private static bool ValidateDate(string str)
        => DateTime.TryParse(str, out DateTime _);

    private static bool ValidateDateFuture(string str) {
        if (!ValidateDate(str))
            return false;

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now <= dt)
            return false;

        return true;
    }

    private static bool ValidateDatePast(string str) {
        if (!ValidateDate(str)) {
            return false;
        }

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now >= dt) {
            return false;
        }

        return true;
    }
}

