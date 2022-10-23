using CommonBase.Extensions;
using CommonBase.Modules.PlantUML;

namespace TestPlantUMLCreator // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static readonly string ClassDiagramFilePath = "C:\\Temp\\PlantCreator\\ClassDiagram.md";
        static readonly string ObjectDiagramFilePath = "C:\\Temp\\PlantCreator\\ObjectDiagram.md";
        static void Main(string[] args)
        {
            Console.WriteLine("PlantUML-ClassDiagram");

            DiagramCreationFlags creationFlags = DiagramCreationFlags.TypeExtends
                                                 | DiagramCreationFlags.ClassMembers
                                                 | DiagramCreationFlags.InterfaceMembers
                                                 | DiagramCreationFlags.InterfaceExtends 
                                                 //| DiagramCreationFlags.ImplementedInterfaces 
                                                 | DiagramCreationFlags.ClassRelations;

            CreateUMLClassDiagram(ClassDiagramFilePath, creationFlags, typeof(Course), typeof(Student), typeof(Teacher));//, typeof(Course), typeof(CourseType));

            var t1 = new Teacher { FirstName = "Gerhard", LastName = "Gehrer", Title = "DI" };
            var c1 = new Course { Teacher = t1, Designation = "Introduction to Programming", Description = "An introduction to programming with CSharp." };
            var s1 = new Student { FirstName = "Tobias", LastName = "Gehrer", Number = "IF23616" };
            var s2 = new Student { FirstName = "Hermann", LastName = "Meier", Number = "IF67616" };

            t1.Courses.Add(c1);

            c1.Students.Add(s1);
            c1.Students.Add(s2);
            s1.Courses.Add(c1);
            s2.Courses.Add(c1);

            CreateUMLObjectDiagram(ObjectDiagramFilePath, 1, new [] { c1 });

            Stack stack = new Stack();

            CreateUMLObjectDiagram(ObjectDiagramFilePath, 100, new[] { stack });
            stack.Push(1);
            CreateUMLObjectDiagram(ObjectDiagramFilePath, 100, new[] { stack });
            stack.Push(2);
            CreateUMLObjectDiagram(ObjectDiagramFilePath, 100, new[] { stack });
            stack.Push(3);
            CreateUMLObjectDiagram(ObjectDiagramFilePath, 100, new[] { stack });

        }

        public static void CreateUMLClassDiagram(string filePath, DiagramCreationFlags diagramCreationFlags, params Type[] types)
        {
            var lines = new List<string>();

            lines.Add("# Kurssystem");
            lines.Add("");
            lines.Add("```plantuml classdiagram");
            lines.Add("@startuml classdiagram");

            lines.AddRange(UMLCreator.DefaultClassSkinparam);

            lines.Add(" package entities #whitesmoke {");
            foreach (var item in types)
            {
                lines.Add($"  class {item.Name}");
            }
            lines.Add("}");
            lines.AddRange(UMLCreator.CreateClassDiagram(diagramCreationFlags, types));

            lines.Add("@enduml");
            lines.Add("```");

            File.WriteAllLines(filePath, lines.ToArray());
        }
        public static void CreateUMLObjectDiagram(string filePath, int deep, params Object[] objects)
        {
            var lines = new List<string>();

            lines.Add("# Kurssystem");
            lines.Add("");
            lines.Add("```plantuml objectdiagram");
            lines.Add("@startuml objectdiagram");

            lines.AddRange(UMLCreator.DefaultObjectSkinparam);

            lines.AddRange(UMLCreator.CreateObjectDiagram(deep, objects));

            lines.Add("@enduml");
            lines.Add("```");

            File.WriteAllLines(filePath, lines.ToArray());
        }
    }
}