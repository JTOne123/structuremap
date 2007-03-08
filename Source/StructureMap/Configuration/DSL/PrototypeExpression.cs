using System;
using StructureMap.Graph;

namespace StructureMap.Configuration.DSL
{
    public class PrototypeExpression<T> : MementoBuilder<PrototypeExpression<T>>
    {
        private readonly T _prototype;
        private PrototypeMemento _memento;

        public PrototypeExpression(T prototype) : base(typeof (T))
        {
            _prototype = prototype;
        }

        protected override InstanceMemento memento
        {
            get { return _memento; }
        }

        protected override PrototypeExpression<T> thisInstance
        {
            get { return this; }
        }

        protected override void configureMemento(PluginFamily family)
        {
            _memento.Prototype = (ICloneable) _prototype;
        }

        protected override void validate()
        {
            // TODO
        }

        protected override void buildMemento()
        {
            _memento = new PrototypeMemento(string.Empty, (ICloneable) _prototype);
        }
    }
}