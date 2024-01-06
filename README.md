<img src="./43fea6f1ce0be7ff03d135f36e96792d8e52f82c.png"
style="width:11.6913in;height:0.88298in" />

First of all, I made the necessary analyzes. I made a list of which
tables are
needed.<img src="./media/image1.jpeg" style="width:6.29722in;height:8.39375in"
alt="C:\Users\oguzh\AppData\Local\Microsoft\Windows\INetCache\Content.Word\WhatsApp Image 2024-01-05 at 04.18.45_50822486.jpg" />

After making a few additions, I decided on the tables to be created.
Then we drew the ER Diagram before creating these tables, this task was
undertaken by my friend Ender.

![](./media/image2.png)

Then I created the tables and drew the Database schema.

<img src="./media/image3.png"
style="width:1.48852in;height:0.83043in" /><img src="./media/image4.png"
style="width:1.49028in;height:0.81818in" /><img src="./media/image5.png"
style="width:1.64748in;height:0.74162in" /><img src="./media/image6.png"
style="width:1.14707in;height:0.72115in" /><img src="./media/image7.png"
style="width:1.50909in;height:0.43246in" />

<img src="./media/image8.png"
style="width:6.29097in;height:3.57569in" />

Then I started making form designs.

Home Screen :

<img src="./media/image9.png" style="width:2.19484in;height:3.0093in" />

The screen that appears when we press the login button:

<img src="./media/image10.png"
style="width:2.05513in;height:2.85965in" />

Registration panel :

<img src="./media/image11.png"
style="width:2.08042in;height:2.85358in" />

The panel that comes when we log in:

<img src="./media/image12.png"
style="width:3.6548in;height:2.16313in" />

<img src="./media/image13.png"
style="width:6.32845in;height:3.68485in" />

This is the image that comes when I click on the Cars tab. I added a
query that lists the cars report on the right side by brand and I used
Stored Procedure here.

<img src="./media/image14.png"
style="width:5.38794in;height:1.7028in" />

<img src="./media/image15.png"
style="width:5.12875in;height:3.01212in" />

On the left side is the order panel. In the order panel, I added our
vehicle's Brand, Model, Color and username query as a security question.

<img src="./media/image16.png"
style="width:5.53939in;height:3.22541in" />

When we click on the "Place order" button, our order is created.

The panel that appears when we click on the service button. On the left
side there is a panel for us to create an appointment request.

<img src="./media/image17.png"
style="width:5.50448in;height:3.18699in" />

<img src="./media/image18.png"
style="width:5.03056in;height:2.93856in" />

This is the image that appears when we click the create request button.
I joined two tables using inner join to reflect two different tables to
a single datagridview

<img src="./media/image19.png"
style="width:3.07498in;height:2.92695in" />

The appointment we receive on the left side looks like this After
evaluating the condition of the vehicle, the remaining information will
be entered by the admin (Price, Delivery Date, Result)

(After Entry)

<img src="./media/image20.png"
style="width:4.52727in;height:3.42588in" />

Now let's look at the admin panel. First of all, when we log in with a
username called admin, the admin panel tab welcomes us. We have various
buttons on the side, these are Cars, Service, Customers, Backup, Sales
and Exit

<img src="./media/image21.png"
style="width:4.57576in;height:2.6316in" />

First of all, let's start with the Cars panel. This is how the panel
looks like. There are Add Car, Update Price and Remove Car Buttons.

<img src="./media/image22.png"
style="width:3.78679in;height:2.19407in" />

When we press the Add Car button, this form welcomes us, after entering
the car properties we want, when we press the add button, our car is
added. I used the Insert query in this section.

<img src="./media/image23.png"
style="width:1.55758in;height:2.29055in" />

If we enter the desired information, the vehicle is added to our table.

<img src="./media/image24.png"
style="width:4.20509in;height:2.44849in" />

When we press the Update Price button, this form welcomes us.

<img src="./media/image25.png"
style="width:1.99709in;height:2.09987in" />

We enter the new price of our vehicle by selecting the values in the
comboboxes and the price of our vehicle has changed.

<img src="./media/image26.png"
style="width:5.65303in;height:3.2303in" />

Finally, with the Delete query, the car with the selected id is deleted
and then the deleted vehicle is added to the Deleted Cars Table with the
trigger I wrote, and the Deleted Cars button shows us this table.

<img src="./media/image27.png"
style="width:6.29722in;height:2.10278in" /><img src="./media/image28.png" style="width:6.29583in;height:3.5in" />

<img src="./media/image29.png" style="width:6.3in;height:1.3in" />

<img src="./media/image30.png"
style="width:6.29444in;height:3.67639in" />

In the service part, we manually enter the missing information in this
way, that is, the date on which our vehicle will leave the service, the
service price and the service result. And the values we enter are added
to the table, here I used the update query.

<img src="./media/image31.png"
style="width:6.29444in;height:3.66181in" />

In the customers section, I added 2 listing methods, one according to
the name we entered and the other according to all customers. In the all
customers section, I used the customer table directly in the customer
table and the stored procedure in the according to the name section.
<img src="./media/image32.png"
style="width:3.10236in;height:1.08364in" />

<img src="./media/image33.png"
style="width:4.20462in;height:2.44094in" /><img src="./media/image34.png"
style="width:4.20939in;height:2.44882in" /><img src="./media/image35.png"
style="width:4.19685in;height:2.44153in" />

When we click on the button, I wrote a code that saves the database with
.bak extension to the backups folder in C. I think I will add a return
from backup button as soon as possible.

<img src="./media/image36.png"
style="width:6.29722in;height:1.75139in" /><img src="./media/image37.png"
style="width:6.29583in;height:3.67153in" />

The sales section is a report that shows how many vehicles sold in
total. I wrote a stored procedure in this section.
<img src="./media/image38.png"
style="width:6.29028in;height:2.13681in" />

In the procedure I wrote, I asked the Sales table to count the total
number of that vehicle model in the Sales table and assign it to the
table named TotelSales, and I created a table containing the vehicle
model and total sales columns.

<img src="./media/image39.png"
style="width:6.29028in;height:3.63264in" />

Back buttons take us to the Login form.

I will try to add the options to save the data as pdf and assign the txt
file to the table as soon as possible.
