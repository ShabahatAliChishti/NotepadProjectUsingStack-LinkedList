using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotepadCore.Services
{
    public class UndoRedoClass
    {
        private static Stack<string> UndoStack = new Stack<string>();
        private static Stack<string> RedoStack = new Stack<string>();
        public UndoRedoClass()
        {
            UndoStack = new Stack<string>();
            RedoStack = new Stack<string>();
        }

        public void Clear()
        {
            UndoStack.Clear();
            RedoStack.Clear();
        }

        public void AddItem(string item)
        {
            UndoStack.Push(item);
        }

        public string Undo()
        {
            string final = string.Empty;
            if (UndoStack.Count() > 0)
            {
                string item = UndoStack.Pop();

                RedoStack.Push(item);



                string removecomma = item.Remove(item.Length - 1);

                if (removecomma.Contains(" ") || removecomma != "")
                {
                    final = removecomma;
                }
                EditOperation.txtAreaTextChangeRequired = true;
                return final;

            }
            else
            {
                EditOperation.txtAreaTextChangeRequired = true;

                return final;
            }

        }


        public string Redo()
        {
            string final = string.Empty;

            if (RedoStack.Count() > 0)
            {
                //if (RedoStack.Count == 0)
                //return UndoStack.First();
                string item = RedoStack.Pop();
                UndoStack.Push(item);

                EditOperation.txtAreaTextChangeRequired = true;
                return UndoStack.First();
            }
            else
            {
                EditOperation.txtAreaTextChangeRequired = true;

                return final;
            }
        }

        public bool CanUndo()
        {
            return UndoStack.Count > 1;
        }

        public bool CanRedo()
        {
            return RedoStack.Count >=1;
        }

        public List<string> UndoItems()
        {
            return UndoStack.ToList();
        }

        public List<string> RedoItems()
        {
            return RedoStack.ToList();
        }
    }
}
