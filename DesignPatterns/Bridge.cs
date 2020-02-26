namespace DesignPatterns
{
    /// <summary>
    /// The implementor: the abstract class, and concrete implementation of one side of the relation
    /// </summary> 
    public interface IBridgeAbstraction
    {
        void Build();
    }
    
    abstract class BridgeAbstraction : IBridgeAbstraction
    {
        public abstract void Build();
    }

    class ConcreteBridge1 : BridgeAbstraction
    {
        public override void Build()
        {
        }
    }

    class ConcreteBridge2 : BridgeAbstraction
    {
        public override void Build()
        {
        }
    }
    
    
    /// <summary>
    /// The abstract class, and concrete implementation of other side of the relations 
    /// </summary>
    public abstract class AbstractionBridgeSupplier
    { 
        public abstract void BuildBridge(IBridgeAbstraction bridge);
    }

    public class ConcreteBridgeSupplier : AbstractionBridgeSupplier
    {
        public override void BuildBridge(IBridgeAbstraction bridge)
        {
            bridge.Build();
        }
    }


    /// <summary>
    /// The client:  the intermediary between the two independently varying sides 
    /// </summary>
    public class ConcreteBridgeBuilder
    {
        public ConcreteBridgeBuilder()
        {
            ConcreteBridgeSupplier supplier = new ConcreteBridgeSupplier();
            supplier.BuildBridge(new ConcreteBridge1());
            supplier.BuildBridge(new ConcreteBridge2());
        }
    }
}
