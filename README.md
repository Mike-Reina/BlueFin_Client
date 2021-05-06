# BlueFin_Client

This client will show the abiltiy to access some of the RESTful endpoints for the BlueFinInc Web App.

## GetProductDetail
The GetProductDetail task will allow the client to ping the Web App for details of a specific product.

It accepts the Product Code(int) and Product Type(str "Equipment" or "Livestock").

If the Product Code is valid it will retrieve the product model and print the details to the CLI.

## Input:
```
 Console.WriteLine("Please provide Equipment Id #");
 int equipInput = Convert.ToInt32(Console.ReadLine(1));
 Console.WriteLine();
 Console.WriteLine("Equipment #" + equipInput + " details are the following");
 GetProductDetail(equipInput, "Equipment").Wait(); 
 Console.WriteLine();

 Console.WriteLine("Please provide Equipment Id #");
 int liveInput = Convert.ToInt32(Console.ReadLine(1));
 Console.WriteLine();
 Console.WriteLine("Equipment #" + liveInput + " details are the following");
 GetProductDetail(liveInput, "Livestock").Wait();
 Console.WriteLine();
```

## Output:

```
Please provide Equipment Id #
1

Equipment #1 details are the following

Product Name: JBL ProFlora m1003 CO2 # 1
Manufacturer: JBL
Description:
CO2 fertilizer system with 2 kg refillable cylinder and pH control instrument. Complete system with: 2 kg CO2 cylinder with stand, pressure regulator, 
pH control instrument, CO2 diffusion reactor JBL Taifun 430 mm, 2 meter CO2 special hose, CO2 non-return valve, KH Test. With pH control instrument(JBL pH-Control), 
which automatically regulates CO2 supply and adjusts to the pH level selected(incl.calibration solution but without pH electrode!). 110 - 240V; 50 - 60Hz
Colour: Black
L x W x H: 0 x 0 x 0
Weight: 12kg
Stock: 4
Price: 624.99

Please provide Livestock Id #
1

Livestock #1 details are the following

Product Name: Clown Fish # 1
Description:
The Ocellaris clown fish "Nemo" is a favourite for the beginner and experienced aquarist. 
The black and white ocellaris clown fishes occurs naturally in anemones and is best known from the movie Finding Nemo.The black and white ocellaris clown fish has three white stripes with vibrant black pallets on its body. 
Ocellaris is often confused with the percula clownfish, because of their coloration and stripe patter. The discerning difference is that A Ocellaris has 11 dorsal spines, where the Percula clownfish has 9 or 10. 
Nemo clownfish is often bred in captivity making it a very hardy fish, and good for beginners.It is readily available in the aquarium trade.
Colours: Orange
Care Level: Medium
Temperment: SemiAggresive 
Water Type: Salt
Water Conditions: PH:8.1-8.4, Sg:1.020-1.02 
Max Sixe: 8cm
Stock: 17
Price: 65.50
```

## GetOrderDetails

The GetOrderDetails task will allow the client to ping the Web App for details of a specific order.

The user will be asked to enter the order number of their choice. The task accepts an id (int) which represents the Order number. 

If the Order Number is valid, it will retrieve the order model and print the details to the CLI console.


## Input:

```
//Order
Console.WriteLine("Please provide Order Number #");
int userInput = Convert.ToInt32(Console.ReadLine(5));
Console.WriteLine();
Console.WriteLine("Order #" + userInput + " details are the following");
Console.WriteLine();
GetOrderDetails(userInput).Wait();

```

## Output:

```
Please provide Order Number #
3

Order #3 details are the following

Order No: 5
Customer Name: Peter C
Eircode: D14F666
Number: +353830492456
Payable Amount in EUR: 131.00
Does the order contain livestock? Yes, it does!
Placed on: 14/04/2021 22:36:59
Products Ordered: || Livestock Items  -- Product Code: 1, Name: Common Clown Fish, Qty: 2

```
## An Example CLI:

![image](https://drive.google.com/uc?export=view&id=1fepa9JnGbw5md5qIoYAGEe20n49JsNZp)

