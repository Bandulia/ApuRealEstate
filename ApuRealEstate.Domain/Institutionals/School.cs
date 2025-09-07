using ApuRealEstate.Institutionals;

namespace ApuRealEstate.Institutionals
{
    public sealed class School : Institutional
    {
        protected override decimal CostPerSquareMeterPerMonth => 30m;

        public override string ToString()
            => $"School · {Address.City}, {Address.Country} · {SquareMeters} m² · {NumOfRooms} rooms";

        public override string GetDescription()
            => $"School located at {Address.Street}, {Address.City}.\n" +
               $"Rooms: {NumOfRooms}, Size: {SquareMeters} m²\n" +
               $"Monthly cost: {AccommodationCost()}";
    }
}
