using Microsoft.EntityFrameworkCore;

public static class SeedData {
    // this is an extension method to the ModelBuilder class
    // take any class and can extend to your own method
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<Province>().HasData(
            GetProvinces()
        );
        modelBuilder.Entity<City>().HasData(
            GetCities()
        );
    }
    public static List<Province> GetProvinces() {
        List<Province> Provinces = new List<Province>() {
            new Province() {    // 1
                ProvinceName="Canucks",
                ProvinceCode="BC",
            },
            new Province() {    //2
                ProvinceName="Sharks",
                ProvinceCode="CA",
            },
            new Province() {    // 3
                ProvinceName="Oilers",
                ProvinceCode="AB",
            },
            
        };

        return Provinces;
    }

    public static List<City> GetCities() {
        List<City> Cities = new List<City>() {
            new City {
                CityId = 1,
                CityName = "Sven",
                Population = 3,
                ProvinceCode = "CA",
            },
            new City {
                CityId = 2,
                CityName = "Hendrik",
                Population = 3,
                ProvinceCode = "CA",
            },
            new City {
                CityId = 3,
                CityName = "John",
                Population = 3,
                ProvinceCode = "CA",
            },
            new City {
                CityId = 4,
                CityName = "Sven",
                Population = 3,
                ProvinceCode = "BC",
            },
            new City {
                CityId = 5,
                CityName = "Hendrik",
                Population = 3,
                ProvinceCode = "BC",
            },
            new City {
                CityId = 6,
                CityName = "John",
                Population = 3,
                ProvinceCode = "BC",
            },
            new City {
                CityId = 7,
                CityName = "Sven",
                Population = 3,
                ProvinceCode = "AB",
            },
            new City {
                CityId = 8,
                CityName = "Hendrik",
                Population = 3,
                ProvinceCode = "AB",
            },
            new City {
                CityId = 9,
                CityName = "John",
                Population = 3,
                ProvinceCode = "AB",
            },
            
        };

        return Cities;
    }
}