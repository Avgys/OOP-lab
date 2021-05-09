using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Plugins
{
    using Figures;
    using Factory;
    using DrawNamespace;
    public class PluginControl
    {
        List<Assembly> PluginList;
        Paint paintRef;

        public PluginControl(Paint paint)
        {
            paintRef = paint;
            PluginList = new List<Assembly>();
            //LoadPlugin("C:\\Users\\ilyuh\\Desktop\\Main Projects For Study\\trapeze\\bin\\Debug\\net5.0-windows\\Trapeze.dll");
        }

        public Button LoadPlugin(string name)
        {
            try
            {
                Assembly inputDll = Assembly.LoadFrom(name);
                Type[] types = inputDll.GetTypes();
                Type figFactory = null;
                for (int i = 0; i < types.Length; i++)
                {
                    //Type temp = types[i];
                    //while (temp.BaseType != typeof(Object))
                    //    temp = temp.BaseType;
                    //if (temp == typeof(FiguresFactory))
                    //{
                    //    figFactory = types[i];
                    //}
                    if (typeof(FiguresFactory).IsAssignableFrom(types[i]))
                        figFactory = types[i];
                }

                if (figFactory != null)
                {
                    //for (int i = 0; i < PluginList.Count; i++) // Checking isAdded
                    //{
                    //    if(PluginList[i] == inputDll)
                    //    {
                    //        MessageBox.Show("This dll already added.");
                    //        return null;
                    //    }
                    //}
                    PluginList.Add(inputDll);
                    Button b = new Button();

                    b.Content = inputDll.GetName().ToString().Substring(0, inputDll.GetName().ToString().IndexOf(","));
                    b.Click += delegate (object sender, RoutedEventArgs e)
                    {
                    //MessageBox.Show("sran'");
                    paintRef.SetFactory(Activator.CreateInstance(figFactory) as FiguresFactory);
                    };
                    return b;
                }
            }
            catch (System.BadImageFormatException)
            {
                MessageBox.Show("Format of the executable (.exe) or library (.dll) is invalid");
            }
            MessageBox.Show("Factory not found");
            return null;
        }

        public Type FindType(string typeName)
        {
            Type type = null;
            for (int i = 0; i < PluginList.Count && type == null; i++)
            {
               type = PluginList[i].GetType(typeName);
            }
            return type;
        }
    }
}
