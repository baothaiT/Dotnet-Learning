#

## Packages

dotnet add package Quartz
dotnet add package Quartz.Extensions.Hosting


### Run docker
docker build -t thaibao/cronjobapi:latest .
docker run thaibao/cronjobapi:latest .
docker push thaibao/cronjobapi:latest


kubectl apply -f k8s/cronjob.yaml
