namespace Player
{
    public interface IEntityInputSource
    {  
         float Direction { get; }
         bool Jump { get; }
         bool LongJump { get; }
         void ResetOneTimeActions();
    }
}