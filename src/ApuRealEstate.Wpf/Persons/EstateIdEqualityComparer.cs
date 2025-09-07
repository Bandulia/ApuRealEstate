namespace ApuRealEstate.Persons
{
    internal sealed class EstateIdEqualityComparer : IEqualityComparer<Estate.Estate>
    {
        public bool Equals(Estate.Estate? x, Estate.Estate? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return string.Equals(x.Id, y.Id, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Estate.Estate obj)
            => StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Id);
    }
}
