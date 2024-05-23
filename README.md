IMPORTANT!
When you download this repo as a .zip file or clone it, it loses the multiple startup projects that is necessary to run the solution successfully.
DO the following to make it run correctly so that both the Web frontend and the backend API starts up simultaneously:

Configure Multiple Startup Projects:

In the Solution Property Pages window, select the Startup Project node.
Choose Multiple startup projects.
Set the Action to Start for each project you want to run.
In the Project column select the Start Action for PaySpace.Calculator.API
In the Project column select the Start Action for PaySpace.Calculator.Web
Click Apply and then OK.
Now Run the Solution and two instances of your default browser will open up - one with the Swagger API end-point(s) and another one for the front end.
