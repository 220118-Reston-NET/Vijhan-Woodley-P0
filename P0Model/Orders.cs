namespace P0Model
{
    public class Orders
    {
        public int OrderID { get; set; }
        private List<SmoothieModel> _listOfSmoothies;
        public List<SmoothieModel> ListOfSmoothies
        {
            get { return _listOfSmoothies; }
            set { _listOfSmoothies = value; }
        }
        
        public string StoreAdress { get; set; }

        public double totalPrice { get; set; }

        public Orders()
        {
           _listOfSmoothies = new List<SmoothieModel>()
            {
                new SmoothieModel()
            }; 
        }

         public void AddSmoothie(SmoothieModel _smoothie)
        {
            _listOfSmoothies.Add(_smoothie);
            
        }
    }
}