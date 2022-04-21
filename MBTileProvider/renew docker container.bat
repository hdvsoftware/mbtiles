docker build -t mbtileprovider .
docker stop mbtileprovider
docker rm mbtileprovider
REM docker run -d -v C:/GIS/netherlands.mbtiles:/GIS/mapdata.mbtiles -p 5000:80 --restart always --name mbtileprovider mbtileprovider 
docker run -d -v C:/GIS/countries-raster.mbtiles:/GIS/mapdata.mbtiles -p 5000:80 --restart always --name mbtileprovider mbtileprovider 