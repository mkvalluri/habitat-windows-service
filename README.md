# Habitat windows service

Sample project to package and deploy windows service using habitat.

### Service description
Basic service which writes to a file saying the service is up. This is based on the blog post on Habitat (<a href="https://www.habitat.sh/blog/2017/12/Packaging-Windows-Services/">blog post</a>) with few modifications according to latest builds.

### Contributors
Murali Valluri (mvalluri.pub@gmail.com)

### Pre-Requisites
- Windows machine.
- Docker
- Habitat

### Steps to run the service
```
# Clone the repo and cd to the repo
git clone 
cd habitat-windows-service

# Enter habitat studio
hab studio enter

# Build the application
build .

# Start the service
hab start ORIGIN_NAME/testioservice

# Verify that there are no errors
Get-SupervisorLog

# Verify that service is running
Get-Service TestIOService

# Watch the log file being updated every 20 secs
Get-Content C:\hab\svc\testioservice\data\status.txt -Wait

# Stop the service using
hab stop ORIGIN_NAME/testioservice

```

### To-Do
- Updating configurations
- Health checks
- Using environment variables
- Connecting to another service
- Uploading to Habitat origin