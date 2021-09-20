using System;
 
public class Node
{
    private Node[] Children;
    private string Text;

    // констуктор узла дерева
    public Node(string text, params Node[] children)
    {
        Text = text;
        Children = children;
    }

    // при создании родителя ребенок уже существует
    public static Node AddNodes(string text, params Node[] children)
    {
        return new Node(text, children);
    }

    // печать детей 
    private string PrintChildren (string prefix, bool isLast)
    {
        string thisString = "";
        string nextPrefix = "";
        
        // решение о создании префикса
        if (isLast)
        {
            thisString = prefix + "└─" + Text + "\n";
            nextPrefix = prefix + "  ";
        }
        else
        {
            thisString = prefix + "├─" + Text + "\n";
            nextPrefix = prefix + "| ";
        }

        // печать детей
        for (int i = 0; i < Children.Length - 1; i++)
            thisString += Children[i].PrintChildren(nextPrefix, false);
        
        // отдельная печать последнего ребенка
        if (Children.Length > 0)
            thisString += Children[Children.Length - 1].PrintChildren(nextPrefix, true);

        return thisString;
    }

    // печать первого элемента
    public override string ToString() 
    {
        string thisString = Text + "\n";

        string nextPrefix = "";
        // печать детей
        for (int i = 0; i < Children.Length - 1; i++)
          thisString += Children[i].PrintChildren(nextPrefix, false);
        
        // отдельная печать последнего ребенка
        if (Children.Length > 0)
            thisString += Children[Children.Length - 1].PrintChildren (nextPrefix, true);

        return thisString;
    }
}

public static class Program
{
    public static void Main()
    {
        Node Root = 
            Node.AddNodes("A", 
                Node.AddNodes("B", 
                    Node.AddNodes("C", 
                        Node.AddNodes("D", 
                            Node.AddNodes("Y"), 
                            Node.AddNodes("Z")
                        )
                    ),
                    Node.AddNodes("E", 
                        Node.AddNodes("F")
                    ),
                    Node.AddNodes("G", 
                        Node.AddNodes("H"),
                        Node.AddNodes("I")
                    )
                ),
                Node.AddNodes("X"),
                Node.AddNodes("J", 
                    Node.AddNodes("K", 
                        Node.AddNodes("L")
                    ),
                    Node.AddNodes("M")
                ),
                Node.AddNodes("T")
            ); 
                
        Console.WriteLine(Root);
    }
}