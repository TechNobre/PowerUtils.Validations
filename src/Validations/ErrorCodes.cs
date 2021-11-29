namespace PowerUtils.Validations
{
    public static class ErrorCodes
    { // DONE
        private const string PATTERN_ERROR_CODE_WITH_LIMIT = "{0}:{1}"; // {0} => ERROR CODE, {1} => LIMIT

        public const string REQUIRED = "REQUIRED";

        public const string INVALID = "INVALID";

        public const string UNAUTHORIZED = "UNAUTHORIZED";
        public const string FORBIDDEN = "FORBIDDEN";

        public const string MIN = "MIN";
        public const string MAX = "MAX";

        public const string MIN_DATETIME_UTCNOW = "MIN:DATETIME_UTCNOW";
        public const string MAX_DATETIME_UTCNOW = "MAX:DATETIME_UTCNOW";

        public const string ALREADY_EXISTS = "ALREADY_EXISTS";

        public const string NOT_FOUND = "NOT_FOUND";

        public static string GetMinFormatted(string min)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min);
        }

        public static string GetMaxFormatted(string max)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max);
        }

        public static string GetMinFormatted(double min)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString().Replace(",", "."));
        }

        public static string GetMaxFormatted(double max)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString().Replace(",", "."));
        }

        public static string GetMinFormatted(long min)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min);
        }

        public static string GetMaxFormatted(long max)
        { // DONE
            return string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max);
        }
    }
}