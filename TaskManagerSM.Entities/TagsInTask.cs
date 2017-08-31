namespace TaskManagerSM.Entities
{
    public class TagsInTask : DomainObject
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}