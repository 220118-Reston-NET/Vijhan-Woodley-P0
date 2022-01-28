using P0DL;
using P0Model;

namespace P0BL {

public class SmoothieBL : ISmoothieBL
{
private IRepository _repo;
public SmoothieBL(IRepository p_repo)
{
    _repo = p_repo;
}

        public SmoothieModel AddSmoothie(SmoothieModel _smoothie)
        {
            
            List<SmoothieModel> listOfSmoothies = _repo.GetAllSmoothie();
            if (listOfSmoothies.Count < 5)
            {
                return _repo.AddSmoothie(_smoothie);
            } else
            {
                throw new Exception("You cannot save more than 5 smoothies");
            }
            return _repo.AddSmoothie(_smoothie);
        }

        public List<SmoothieModel> SearchSmoothie(string s_name)
        {
            List<SmoothieModel> listOfSmoothieSearch = _repo.GetAllSmoothie();
            List<SmoothieModel> SmoothieFound = new List<SmoothieModel>();
            foreach (SmoothieModel item in listOfSmoothieSearch)
            {
                if(item.Name.Contains(s_name, StringComparison.CurrentCultureIgnoreCase))
                {
                    
                    SmoothieFound.Add(item);
                    return SmoothieFound;
                } else
                {
                    throw new Exception("Object " + s_name + " was not found.");
                }
            }
            return SmoothieFound;
        }

}
}