using System;
using System.IO;
using Serialization = System.Runtime.Serialization;

namespace DesignPatterns
{
    /// <summary>
    /// A serializable data object, the attribute
    ///  necessary for simple form of deep copy
    /// </summary>
    [Serializable]
    public class SerializableDataObject 
    {
        public SerializableDataObject(int objectId)
        { 
            
        }

        public int Id { get; set; }
    }

    public static class CommonMethod
    {
        /// <summary>
        /// Serialize and desserializes the DataObject
        ///  creating a new DataObject with the same values as the source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }

    public class BasePrototype : ICloneable
    {
        /// <summary>
        /// Example object, for either shallow or deep copies
        /// </summary>
        public SerializableDataObject DataObject { get; set; }

        /// <summary>
        /// Creates a DataObject when constructed
        ///  Classes inheriting this can do Cones, as shallow copies
        ///  or override Clone to create deep copy
        /// </summary>
        public BasePrototype()
        {
            DataObject = new SerializableDataObject(1);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// Returns a shallow copy via the inherited Clone operation,
    ///  in that the clone operation has a reference to the base class DataObject
    /// </summary>
    public class ShallowPrototype: BasePrototype
    {
        public ShallowPrototype()
        {

        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    /// <summary>
    /// Returns a deep copy, in that the clone operation of the DataObject
    ///  is new copy of the base DataObject
    /// </summary>
    public class DeepPrototype : BasePrototype
    {
        public DeepPrototype()
        {
        }

        /// <summary>
        /// Overrides base Clone operation to create a memberwise clone
        ///  but with a deep copy of the DataObject
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            //clones this, but changes data object to true copy
            // not just reference, of data object
            DeepPrototype tempThis = (DeepPrototype)this.MemberwiseClone();
            tempThis.DataObject.Id += 1;
            tempThis.DataObject = CommonMethod.DeepClone(tempThis.DataObject);
            return tempThis;
        }
    }

}
