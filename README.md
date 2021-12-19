# OuraData

This is a personal project to keep track of my health data (especially sleep) measured by the Oura Ring Gen3.

## Components
- Azure Table Storage
- Azure Function

## Workflow

The Azure Function has a timer trigger, which triggers once per day. It fetches the Data from the Oura Cloud and saves it to an Azure Table Storage 
