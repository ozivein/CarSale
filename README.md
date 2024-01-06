![](RackMultipart20240106-1-sg689f_html_82d6eae1aab4f32b.png) ![Shape1](RackMultipart20240106-1-sg689f_html_a765ab17bd3b76f2.gif)

Subscribe to DeepL Pro to edit this document.
Visit [www.DeepL.com/pro](https://www.deepl.com/pro?cta=edit-document) for more information.

First of all, I made the necessary analyzes. I made a list of which tables are needed. ![](RackMultipart20240106-1-sg689f_html_b6e1ac80a9f79288.jpg)

After making a few additions, I decided on the tables to be created. Then we drew the ER Diagram before creating these tables, this task was undertaken by my friend Ender.

![Shape2](RackMultipart20240106-1-sg689f_html_d5bc2c39b85a7363.gif)

Then I created the tables and drew the Database schema.

![](RackMultipart20240106-1-sg689f_html_49282398f3db5c10.png) ![](RackMultipart20240106-1-sg689f_html_431c1582b2674ea7.png) ![](RackMultipart20240106-1-sg689f_html_9203eff9f9a4ca5e.png) ![](RackMultipart20240106-1-sg689f_html_1949a1812e963b4b.png) ![](RackMultipart20240106-1-sg689f_html_4328403b0da3da89.png)

![](RackMultipart20240106-1-sg689f_html_dbb7ba882c20718.png)

Then I started making form designs.

Home Screen :

![](RackMultipart20240106-1-sg689f_html_15c999ead06890e1.png)

The screen that appears when we press the login button:

![](RackMultipart20240106-1-sg689f_html_efdabc6a627b3353.png)

Registration panel :

![](RackMultipart20240106-1-sg689f_html_bc6e97c289f5f57f.png)

The panel that comes when we log in:

![](RackMultipart20240106-1-sg689f_html_8e567910271a1396.png)

![](RackMultipart20240106-1-sg689f_html_5601961d9730aab8.png)

This is the image that comes when I click on the Cars tab. I added a query that lists the cars report on the right side by brand and I used Stored Procedure here.

![](RackMultipart20240106-1-sg689f_html_7e60f125e8978d6.png)

![](RackMultipart20240106-1-sg689f_html_68c6192bc0bbc379.png)

On the left side is the order panel. In the order panel, I added our vehicle's Brand, Model, Color and username query as a security question.

![](RackMultipart20240106-1-sg689f_html_45e136ad99d0b812.png)

When we click on the "Place order" button, our order is created.

The panel that appears when we click on the service button. On the left side there is a panel for us to create an appointment request.

![](RackMultipart20240106-1-sg689f_html_1183d80bd149c9ad.png)

![](RackMultipart20240106-1-sg689f_html_66c1efecb34a7ca7.png)

This is the image that appears when we click the create request button. I joined two tables using inner join to reflect two different tables to a single datagridview

![](RackMultipart20240106-1-sg689f_html_9cd6fab7bb81def9.png)

The appointment we receive on the left side looks like this After evaluating the condition of the vehicle, the remaining information will be entered by the admin (Price, Delivery Date, Result)

(After Entry)

![](RackMultipart20240106-1-sg689f_html_4edbf563170f756f.png)

Now let's look at the admin panel. First of all, when we log in with a username called admin, the admin panel tab welcomes us. We have various buttons on the side, these are Cars, Service, Customers, Backup, Sales and Exit

![](RackMultipart20240106-1-sg689f_html_d1911713d3bb27bf.png)

First of all, let's start with the Cars panel. This is how the panel looks like. There are Add Car, Update Price and Remove Car Buttons.

![](RackMultipart20240106-1-sg689f_html_5914baf50f488418.png)

When we press the Add Car button, this form welcomes us, after entering the car properties we want, when we press the add button, our car is added. I used the Insert query in this section.

![](RackMultipart20240106-1-sg689f_html_bb8b7f265c16b5d1.png)

If we enter the desired information, the vehicle is added to our table.

![](RackMultipart20240106-1-sg689f_html_50ab21e4d30aff14.png)

When we press the Update Price button, this form welcomes us.

![](RackMultipart20240106-1-sg689f_html_9ff8b97c8d7a542c.png)

We enter the new price of our vehicle by selecting the values in the comboboxes and the price of our vehicle has changed.

![](RackMultipart20240106-1-sg689f_html_93b9a1d71acdf091.png)

Finally, with the Delete query, the car with the selected id is deleted and then the deleted vehicle is added to the Deleted Cars Table with the trigger I wrote, and the Deleted Cars button shows us this table.

![](RackMultipart20240106-1-sg689f_html_72fe386e81a5aa78.png) ![](RackMultipart20240106-1-sg689f_html_4eb7e16d750b558.png)

![](RackMultipart20240106-1-sg689f_html_7f63b20f82fe908e.png)

![](RackMultipart20240106-1-sg689f_html_c2e71e048595a4e1.png)

In the service part, we manually enter the missing information in this way, that is, the date on which our vehicle will leave the service, the service price and the service result. And the values we enter are added to the table, here I used the update query.

![](RackMultipart20240106-1-sg689f_html_d7bde570d9f9fd25.png)

In the customers section, I added 2 listing methods, one according to the name we entered and the other according to all customers. In the all customers section, I used the customer table directly in the customer table and the stored procedure in the according to the name section. ![](RackMultipart20240106-1-sg689f_html_7467be9a7547e512.png)

![](RackMultipart20240106-1-sg689f_html_1c9caf904a1e5978.png) ![](RackMultipart20240106-1-sg689f_html_3919beeb2db0bce9.png) ![](RackMultipart20240106-1-sg689f_html_3ab4f95caf466946.png)

When we click on the button, I wrote a code that saves the database with .bak extension to the backups folder in C. I think I will add a return from backup button as soon as possible.

![](RackMultipart20240106-1-sg689f_html_a5572ef38d3a1e95.png) ![](RackMultipart20240106-1-sg689f_html_fb0910e3fdba18f8.png)

The sales section is a report that shows how many vehicles sold in total. I wrote a stored procedure in this section. ![](RackMultipart20240106-1-sg689f_html_ea742de5d8396856.png)

In the procedure I wrote, I asked the Sales table to count the total number of that vehicle model in the Sales table and assign it to the table named TotelSales, and I created a table containing the vehicle model and total sales columns.

![](RackMultipart20240106-1-sg689f_html_5d6e02c34ae1c266.png)

Back buttons take us to the Login form.

I will try to add the options to save the data as pdf and assign the txt file to the table as soon as possible.
