namespace DevFreela.Core.Entities
{
    // classe abstrata: não pode ser instanciada, mas pode ser herdada
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
    }
}
