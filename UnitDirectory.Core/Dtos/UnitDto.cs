namespace UnitDirectory.Core.Dtos
{
    public record UnitDto(Guid Id, string Name, int? Index, Guid? ParentId)
    {
        public int Level { get; set; }
    }
}
