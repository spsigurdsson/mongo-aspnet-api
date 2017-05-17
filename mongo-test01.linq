<Query Kind="Program">
  <Reference>C:\advicedotnet\Standard\Advice.Optimization.Api\bin\Debug\Advice.BasicTypes.dll</Reference>
  <Reference>C:\advicedotnet\Standard\Advice.Optimization.Api\bin\Debug\Advice.Calculation.Pension.Utilities.dll</Reference>
  <Reference>C:\advicedotnet\Standard\Advice.Optimization.Api\bin\Debug\Advice.Optimization.Api.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\Spsc.Core.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\Spsc.Finance.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\Spsc.Utilties.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\SpsConsulting.Core.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\SpsConsulting.Finance.dll</Reference>
  <Reference>C:\Spsc\src\standard\Spsc.Finance\bin\Debug\netstandard1.6\SpsConsulting.Utilties.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>Advice.BasicTypes</Namespace>
  <Namespace>Advice.BasicTypes.Time</Namespace>
  <Namespace>Advice.BasicTypes.Time.Service</Namespace>
  <Namespace>Advice.BasicTypes.TimeSeries</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.AmountTenures</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.Calculation</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.Constants</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.MoneyMath</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.NominalPayment</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.PaymentStream</Namespace>
  <Namespace>Advice.Calculation.Pension.Utilities.RootFinding</Namespace>
  <Namespace>Advice.Optimization.Api</Namespace>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var client = new MongoClient("mongodb://localhost:27017");
	var database = client.GetDatabase("test");
	//database.DropCollection("dateCounter");
	
	var collection =  database.GetCollection<DateCounter>("dateCounter");
	
	var all =  collection.Find(_ => true).ToList();
	all.Dump();

	var e = new DateCounter()
	{
		LastCount = DateTime.Now,
		Count = 1
	};
	
	
	if (all.Any())
	{
		e = new DateCounter()
		{
			LastCount = DateTime.Now,
			Count = all.Last().Count + 1
		};
	}
	
	collection.InsertOne(e);
	
	all =  collection.Find(_ => true).ToList();
	all.Dump();
	
//
//	Task.Run(() => collection.InsertOne(new DateCounter()
//	{
//		LastCount = DateTime.Now,
//		Count = 1
//	}));
	//.GetCollection<BsonDocument>("bar");

//	foreach (var document in list)
//	{
//		Console.WriteLine(document["Name"]);
//	}
}




public class MongoEntity
{
	public ObjectId _id { get; set; }
}

public class DateCounter : MongoEntity
{
	public DateTime LastCount { get; set; }

	public int Count { get; set; }
}

// Define other methods and classes here
