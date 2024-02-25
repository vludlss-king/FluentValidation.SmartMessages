using FluentValidation.SmartMessages.Collections;
using FluentValidation.SmartMessages.Impl;

namespace FluentValidation.SmartMessages
{
    public abstract class SmartValidator<T> : AbstractValidator<T>
    {
        /// <summary>
        /// Задать условие для выполнения группы правил
        /// </summary>
        public WhenConditionBuilder When(Func<T, bool> predicate, Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            var conditionBuilder = When(predicate, () => action(ruleBag));
            var rulesComponents = ruleBag.ExtractRulesComponents();

            return new WhenConditionBuilder(conditionBuilder, ruleBag);
        }

        /// <summary>
        /// Задать область для переопределения сообщений у группы правил
        /// </summary>
        public GroupBuilder Group(Action<RuleBag> action)
        {
            var ruleBag = new RuleBag();

            action(ruleBag);

            return new GroupBuilder(ruleBag);
        }
    }
}
