# BlueFin_Client

This client will show the abiltiy to access some of the RESTful endpoints for the BlueFinInc Web App.

The GetProductDetail task will allow the client to ping the Web App for details of a specific product.

It accepts the Product Code(int) and Product Tye(str "Equipment or Livestock").

If the Product Code is valid it will retrieve the product model and print the details to the CLI.

## Input:
```
GetProductDetail(1, "Equipment").Wait();
GetProductDetail(1, "Livestock").Wait();
```

## Output:

```
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