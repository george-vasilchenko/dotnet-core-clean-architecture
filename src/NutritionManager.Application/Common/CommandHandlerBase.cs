using System.Threading.Tasks;

namespace NutritionManager.Application.Common
{
    public abstract class CommandHandlerBase<TCommand>
        where TCommand : class
    {
        public abstract Task HandleCommandAsync(TCommand command);
    }
}