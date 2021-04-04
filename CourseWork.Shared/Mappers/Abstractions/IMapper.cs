namespace CourseWork.Shared.Mappers.Abstractions
{
    public interface IMapper<TIn, TOut>
    {
        public TOut MapTo(TIn input);
        public TIn MapFrom(TOut input);
        public TIn MapWithExisting(TIn current, TIn updated);
    }
}
