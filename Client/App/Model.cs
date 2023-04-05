namespace App
{
    public class Model
    {
        public Model()
        {
        }

        public string Name { get; set; }
        public object Figure { get; set; }
        public Client Owner { get; set; }
    }
}