namespace TodoListTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TodoListModels;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void SetProperties()
    {
        
        var item = new ToDoItem();

        item.Id = 1;
        item.Description = "Test ToDo";
        item.CompletedDate = DateTime.Now;

        Assert.AreEqual(1, item.Id);
        Assert.AreEqual("Test ToDo", item.Description);
        Assert.IsNotNull(item.CompletedDate);
    }

    [TestMethod]
    public void IdDefaultValueZero()
    {
        var item = new ToDoItem();
        Assert.AreEqual(0, item.Id);
    }  

    [TestMethod]
    public void DescriptionDefaultValueNull()
    {  
        var item = new ToDoItem();
        Assert.IsNull(item.Description);
    } 

    [TestMethod]
    public void CompletedDateDefaultValueNull()
    { 
        var item = new ToDoItem();
        Assert.IsNull(item.CompletedDate);
    }
}