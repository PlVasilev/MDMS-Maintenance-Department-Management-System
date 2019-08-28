namespace MDMS.GlobalConstants
{
    public abstract class ModelConstants
    {
        public const string PositiveNumberErrorMessage = "Must be 0 or positive number.";
        public const string PositiveNumberFromOneErrorMessage = "Must be positive number.";

        public const string StringLengthNameMessage = "Input length Must at least 1 symbol be no more than";

        public const string MonthRangeErrorMessage= "Months numbe must be between 1 and 12 inclusive.";
        public const string YearRangeErrorMessage = "Months numbe must be between 1900 and 2200 inclusive.";

        public const string RegExVsnMessage = "Vehicle Serial Number must be Exacly 17 symbols english letters or numbers.";
        public const string RegExRegNumberMessage = "Vehicle Registration Number must be Exacly form 3 to 9 symbols english letters or numbers.";

        public const string VehicleAcquiredAfterManufactured = "The Vehicle Acquired must be after Manufactured!";
        public const string VehiclePriceMoreThanDepreciation = "The Vehicle Price Greater than Depreciation!";
        public const string PartAddQuantMoreThanStock = "can not be more than its stock!";
        public const string EndOfReportBeforeStart = "The End of the Report must be after The Start";

        public const string RegExVsn = "^[A-Za-z0-9]{17}$";
        public const string RegExVehRegNumber = "^[A-Za-z0-9]{3,9}$";

        public const string DecimalPositiveMin = "0.00";
        public const string DecimalMax = "79228162514264337593543950335";
        public const double DoublePositiveMin = 0.0;
        public const double DoubleMax = double.MaxValue;
        public const int IntPositiveMin = 0;
        public const int IntPositiveMinOne = 1;
        public const int IntMax = int.MaxValue;

        public const int NameLength = 100;
        public const string NameLengthString = " 100.";
        public const int NameLengthSm = 30;
        public const string NameLengthStringSm = " 30.";
        public const int NameLengthLg = 1000;
        public const string NameLengthStringLg = " 1000.";

        public const int MonthMin = 1;
        public const int MonthMax = 12;
        public const int YearMin = 1900;
        public const int YearMax = 2200;
    }
}
