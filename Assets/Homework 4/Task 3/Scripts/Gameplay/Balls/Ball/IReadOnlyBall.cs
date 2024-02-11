namespace Homework4.Task3
{
    public interface IReadOnlyBall
    {
        Ball IReadOnlyBall { get; }
        ColorType ColorType { get; }
        bool IsActive { get; }
    }
}