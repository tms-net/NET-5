namespace TMS.ShopSimulator
{
    public class Person
    {
        public Person(int processingTime, int personId)
        {
            ProcessingTime = processingTime;
            Name = $"Person-{personId}";
        }

        public int ProcessingTime { get; }
        public string Name { get; }
    }
}