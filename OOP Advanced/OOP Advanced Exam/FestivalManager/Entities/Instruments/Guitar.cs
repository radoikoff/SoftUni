namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int RepairAmountValue = 60;

        public Guitar()
            : base(RepairAmountValue)
        {
        }

    }
}
