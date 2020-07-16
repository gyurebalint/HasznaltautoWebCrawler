# HasznaltautoWebCrawler - hasznaltauto.hu

This is a web crawler which gets car data from Hungary's largest used car website(hasznaltauto.hu). This project is in progress, the algorithm for scraping is done and working, 
the database and model is set up. The problem arose that with its current form it'll take about 16 hours to get all the data into the database. My workaround will be that
I will run this on a Azure vm machine, and set up a check  which checks the id of the car advertisement, if it already exists, doesn't need to open that page,
therefore making it faster.

## Data Analysis
I will implement some filtering and checking after I have the data.
 - (Classification problem) Based on the car's description filter out all the covert car dealership who doesn't pay a subscription fee, instead they put up these ads as their own cars. 
 - (Compressing/Comparing pictures) See if someone uses the same picture for multiple cars either at once, or in different times (this will come in handy in another project*)
 
 
 *On ingatlan.com there are lazy real-estate agents who use the same pictures for multiple property. This is dominant in case of searching for a 'telek' (plot of land).

