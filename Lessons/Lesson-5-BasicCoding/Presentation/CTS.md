# Common type system
The common type system defines how types are declared, used, and managed in the common language runtime.

## Types in .NET
The common type system in .NET supports the following five categories of types:

 - **Classes**:

   A class is a reference type that can be derived directly from another class and that is derived implicitly from System.Object.

 - **Structures**:

   A structure is useful for representing values whose memory requirements are small, and for passing values as by-value parameters to methods that have strongly typed parameters. In .NET, all primitive data types (Boolean, Byte, Char, DateTime, Decimal, Double, Int16, Int32, Int64, SByte, Single, UInt16, UInt32, and UInt64) are defined as structures.

   Like classes, structures define both data (the fields of the structure) and the operations that can be performed on that data (the methods of the structure).

 - **Enumerations**:
   An enumeration is a value type that inherits directly from System.Enum and that supplies alternate names for the values of an underlying primitive type.

 - **Interfaces**:
   An interface defines a contract that specifies a "can do" relationship or a "has a" relationship. Interfaces are often used to implement functionality

 - **Delegates**: 
    Delegates are reference types that serve a purpose similar to that of function pointers in C++. They are used for event handlers and callback functions in .NET. Unlike function pointers, delegates are secure, verifiable, and type safe. A delegate type can represent any instance method or static method that has a compatible signature.

## Type definitions
A type definition includes the following:

 - Any attributes defined on the type.
 - The type's accessibility (visibility).
 - The type's name.
 - The type's base type.
 - Any interfaces implemented by the type.
 - Definitions for each of the type's members.

 ## Type conversion in .NET
 Every value has an associated type, which defines attributes such as the amount of space allocated to the value, the range of possible values it can have, and the members that it makes available.