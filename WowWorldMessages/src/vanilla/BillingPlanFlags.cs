namespace WowWorldMessages.Vanilla;

[Flags]
public enum BillingPlanFlags : byte {
    None = 0,
    Unused = 1,
    RecurringBill = 2,
    FreeTrial = 4,
    Igr = 8,
    Usage = 16,
    TimeMixture = 32,
    Restricted = 64,
    EnableCais = 128,
}

