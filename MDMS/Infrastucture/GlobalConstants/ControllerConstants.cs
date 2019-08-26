namespace MDMS.GlobalConstants
{
    public abstract class ControllerConstants
    {
        public const string InputErrorMessage = "There was a problem with you input.";

        public const string PartProviderErrorMessage = "Part provider with that name already exist.";
        public const string PartErrorMessage = "Part with that name already exist.";
        public const string PartAddStockErrorMessage = "There was a problem with adding stock.";
        public const string PartEditErrorMessage = "There was a problem with editing the part.";
        public const string PartsAddErrorMessage = "You must add at least One part!";

        public const string RepairProviderCreateErrorMessage = "Repair Provider whit that name already Exists.";
        public const string RepairCreateErrorMessage = "Repair with that name already exists.";
        public const string RepairFinalizeErrorMessage = "There was a problem Finalizing the repair.";

        public const string ReportCreateErrorMessage = "Report for those months already Exists.";

        public const string UserEditPaymentErrorMessage = "There was a problem with Editing the Payment.";
        public const string UserAddSalaryErrorMessage = "Salary for that month already Exists!";

        public const string VehicleProviderCreateErrorMessage = "Vehicle Provider whit that name already Exists.";
        public const string VehicleTypeCreateErrorMessage = "Vehicle Type whit that name already Exists.";
        public const string VehicleCreateErrorMessage = "Vehicle VSN already Exists, change VSN.";
        public const string VehicleEditErrorMessage = "You can not Edit Deleted Vehicle!";
    }
}
