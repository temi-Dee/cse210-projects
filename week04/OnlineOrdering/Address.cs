public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _streetAddress = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA() => _country == "USA";

    public string GetFullAddress() =>
        $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
}
