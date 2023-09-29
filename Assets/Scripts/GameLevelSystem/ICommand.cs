

namespace JSB.GameLevelSystem
{
    public enum AllCommandType
    {
        Unset
    }

    public interface ICommand
    {
        public void Execute(StandardGameLevel gameLevel);
    }
}
