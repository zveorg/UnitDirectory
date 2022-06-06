namespace UnitDirectory.Core.Entities
{
    [Serializable]
    public class Unit : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Index { get; set; }

        public Guid? ParentId { get; set; }
    }
}
