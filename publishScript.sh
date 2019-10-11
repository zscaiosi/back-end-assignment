#builds and run Products.API
cd Products.API/
docker build -t productsimage .
docker run -d -p 5000:5000 --name productsservice productsimage
#builds and run Login.API
cd ../Login.API/
docker build -t loginimage .
docker run -d -p 44319:44319 --name loginservice loginimage