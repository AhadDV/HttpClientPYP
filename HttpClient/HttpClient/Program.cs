

using Newtonsoft.Json;
HttpClient client = new();
List<Country> Countries = new();

var Phones = client.GetAsync("http://country.io/phone.json").Result;
var Iso = client.GetAsync("http://country.io/iso3.json").Result;
var Capital = client.GetAsync("http://country.io/capital.json").Result;
var Currency = client.GetAsync("http://country.io/currency.json").Result;
var Contient = client.GetAsync("http://country.io/continent.json").Result;
var Country = client.GetAsync("http://country.io/names.json").Result;


var responsePhoneStr = Phones.Content.ReadAsStringAsync().Result;
var phone = JsonConvert.DeserializeObject<Dictionary<string, string>>(responsePhoneStr);

var responseContientStr = Contient.Content.ReadAsStringAsync().Result;
var contient = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContientStr);

var responseIsoStr = Iso.Content.ReadAsStringAsync().Result;
var iso = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseIsoStr);

var responseCapitalStr = Capital.Content.ReadAsStringAsync().Result;
var capital = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseCapitalStr);

var responseCurrencyStr = Currency.Content.ReadAsStringAsync().Result;
var currency = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseCurrencyStr);

var responseCountryStr = Country.Content.ReadAsStringAsync().Result;
var country = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseCountryStr);

for (int i = 0; i < country.Keys.Count; i++)
{
    Country NewCountry = new Country
    {
        Capital = capital.Values.ToArray()[i],
        Currency = currency.Values.ToArray()[i],
        CountryCode = country.Keys.ToArray()[i],
        Name = country.Values.ToArray()[i],
        Phone = phone.Values.ToArray()[i],
        Contient = contient.Values.ToArray()[i],
        Iso = iso.Values.ToArray()[i]
    };
    Countries.Add(NewCountry);
}


Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "Phone", "ISO", "Capital", "Currency", "Continent", "Code", "Name");
Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "-------", "-----", "----------", "----------", "-----------------------", "----------", "----------");

foreach (var item in Countries)
{
    Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", item.Phone, item.Iso, item.Capital, item.Currency, item.Contient+"        "+item.Id,item.CountryCode, item.Name);
}










