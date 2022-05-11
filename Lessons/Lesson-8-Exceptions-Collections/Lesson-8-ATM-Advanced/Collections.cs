using System;
using System.Collections.Generic;

class Collections
{
    void UseCollections()
    {
        // Пример работы модификаторов доступа класса и свойства
        //var accountHistory = new ATMClient.AccountHistoryStateMachine(new ATMAccount("123"));
        //accountHistory.NextOperation();

        var array = new int[3]; // (123: (4 byte) (4 byte) (4 byte) )
        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Элемент массива {i}: {array[i]}");
        }


        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);

        // ((node) -> (node)-> (node));
        var linked = new LinkedList<int>();
        linked.AddFirst(1);
        //linked.Count;

        var enumereator = linked.GetEnumerator();
        while (enumereator.MoveNext())
        {
            var item = enumereator.Current;
            Console.WriteLine($"Элемент списка {item}");
        }

        foreach (int item in linked)
        {
            Console.WriteLine($"Элемент списка {item}");
        }

        var queue = new Queue<int>();

        // ( 3 2 1 ) - enqueue
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // ( 3 2 ) - dequeue -> 1
        queue.Dequeue();

        var stack = new Stack<int>();

        // ( 1 2 3 ) - push
        // (3)
        // (2)
        // (1)
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // ( 1 2 ) - pop -> 3
        stack.Pop();

        Console.WriteLine($"Количество элементов стэка {stack.Count}");

        var dict = new Dictionary<string, int>();
        dict["1"] = 1;
        var value1 = dict["1"];
    }
}