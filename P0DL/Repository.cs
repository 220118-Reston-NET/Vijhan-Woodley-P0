using System.Text.Json;
using P0Model;

namespace P0DL {


    public class Repository : IRepository
    {
        private string _filepath = "../P0DL/Database/";
        private string _jsonString;
        public SmoothieModel AddSmoothie(SmoothieModel _smoothie)
        {
            string path = _filepath + "Smoothie.json";
            List<SmoothieModel> listOfSmoothies = GetAllSmoothie();
            listOfSmoothies.Add(_smoothie);
            _jsonString = JsonSerializer.Serialize(listOfSmoothies, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path , _jsonString);

            return _smoothie;
        }

        public List<SmoothieModel> GetAllSmoothie()
        {
            _jsonString = File.ReadAllText(_filepath + "Smoothie.json");

            return JsonSerializer.Deserialize<List<SmoothieModel>>(_jsonString);
        }
    }
}