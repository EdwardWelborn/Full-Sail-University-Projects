using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_ConvertedData
{
    class RestaurantProfile
    {
        private string restaurantName { get; set; }
        private string address { get; set; }
        private string phone { get; set; }
        private string hoursOfOperation { get; set; }
        private string price { get; set; }
        private string uSACityLocation { get; set; }
        private string cuisine { get; set; }
        private decimal foodRating { get; set; }
        private decimal serviceRating { get; set; }
        private decimal ambienceRating { get; set; }
        private decimal overallRating { get; set; }
        private decimal overAllPossibleRating { get; set; }
        private string endIndicator = "!end";

        public RestaurantProfile(string RestaurantName, string Address, string Phone, string HoursOfOperation, string Price, string USACityLocation, string Cuisine, decimal FoodRating, 
            decimal ServiceRating, decimal AmbienceRating, decimal OverallRating, decimal OverAllPossibleRating, string EndIndicator)
        {
            restaurantName = RestaurantName;
            address = Address;
            phone = Phone;
            hoursOfOperation = HoursOfOperation;
            price = Price;
            uSACityLocation = USACityLocation;
            cuisine = Cuisine;
            foodRating = FoodRating;
            serviceRating = ServiceRating;
            ambienceRating = AmbienceRating;
            overallRating = OverallRating;
            overAllPossibleRating = OverAllPossibleRating;
            endIndicator = EndIndicator;
        }
        public override string ToString()
        {
            string profilestr = $"{this.restaurantName,-35} ${this.address,-15} {this.phone} {this.hoursOfOperation,-35} ${this.price,-15} {this.uSACityLocation} {this.cuisine,-35} {this.foodRating,-15} " +
                $"{this.serviceRating} {this.ambienceRating,-35} {this.overallRating,-15} {this.overAllPossibleRating} { this.endIndicator}";
            return profilestr;
        }
    }
}
/*
 * SELECT `RestaurantProfiles`.`id`,
    `RestaurantProfiles`.`RestaurantName`,
    `RestaurantProfiles`.`Address`,
    `RestaurantProfiles`.`Phone`,
    `RestaurantProfiles`.`HoursOfOperation`,
    `RestaurantProfiles`.`Price`,
    `RestaurantProfiles`.`USACityLocation`,
    `RestaurantProfiles`.`Cuisine`,
    `RestaurantProfiles`.`FoodRating`,
    `RestaurantProfiles`.`ServiceRating`,
    `RestaurantProfiles`.`AmbienceRating`,
    `RestaurantProfiles`.`ValueRating`,
    `RestaurantProfiles`.`OverallRating`,
    `RestaurantProfiles`.`OverallPossibleRating`
    */
