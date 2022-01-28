using P0Model;

namespace P0BL;
public interface ISmoothieBL
{
/// <summary>
/// Will add smoothie data to the database
/// </summary>
/// <param name="_smoothie"></param>
/// <returns></returns>
SmoothieModel AddSmoothie(SmoothieModel _smoothie);

List<SmoothieModel> SearchSmoothie(string s_name);

}
