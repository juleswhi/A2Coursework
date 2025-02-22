namespace Model;
internal static class Validation {

    public enum ValidationType {
        NAME,
        PRICE,
        OTHER,
    }

    public static bool Validate(this string str, ValidationType type) {
        return type switch {
            // May only have ascii letters and digits
            // And not longer than 20 digits
            NAME => str.Any(x => !char.IsAsciiLetterOrDigit(x)) && str.Length < 20,
            _ => true
        };
    }

    public static bool Validate(this int num, ValidationType type) {
        return type switch {
            PRICE => num < 1_000_000 && num >= 0,
            _ => true
        };
    }

}

