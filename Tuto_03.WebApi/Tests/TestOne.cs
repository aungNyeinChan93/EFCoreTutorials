namespace Tuto_03.WebApi.Tests
{
    public class TestOne
    {

        public string ClassName { get; set; } = "Test One Class";

        public void WhoAmI()
        {
            Console.WriteLine($" I ma {this.ClassName}");
        }


    }
}
