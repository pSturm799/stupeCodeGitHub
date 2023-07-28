namespace CrmTestkonsolenprojekt_4_8.Model
{
    public class DaysPerMonthModel
    {
        /// <summary>
        /// </summary>
        public int Month { get; set; }

        public int Year { get; set; }
        public int DaysPerMonth { get; set; }


        public double RentValue
        {
            get { return RentInMonth / 30 * DaysPerMonth; }
            set { }
        }

        public double RentInMonth { get; set; } = 200000;
    }
}