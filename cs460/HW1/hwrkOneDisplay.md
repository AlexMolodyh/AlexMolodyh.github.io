---
title: Homework 1 Code Display
layout: default
---


## These are the requirements listed for homework 1.

### The first requirement is the use of Bootstrap. 
#### I have provided a Bootstrap navbar in my landing page and homework 1 page. 
[Landing Page](https://goo.gl/CynbUB) and 
[Homework 1 Page](https://goo.gl/RLCGrC)

```html
<nav class="navbar navbar-default navbar-static-top" role="navigation">
    <div class="container-fluid">
        <div class="navbar-header">
            <a id="navbarTitle" class="navbar-brand" href="#">WOU Senior Year</a>
        </div>
        <ul class="nav navbar-nav">
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" 
                aria-haspopup="true" aria-expanded="false">CS460 <span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <li><a href="cs460/homework1/homeworkOne.html">Homework 1</a></li>
                </ul>
            </li>
        </ul>
    </div>
</nav>
    
    
```


##### I used two columns in my landing page.
[Landing Page](https://goo.gl/CynbUB)

```html
<div class="container" id="contentFont">
    <div class="row">
        <div class="col-md-6">
            <h1>Introduction</h1>
            <h3>I'm a computer science senior at Western Oregon University
            who is planning on becoming a software engineer. I strive to develop 
            reusable Object Oriented software and write clean code. </h3>
        </div>
        <div class="col-md-6">
            <dl>
                <dt><h1>Website Purpose</h1></dt>
                <dd>
                    <h3>The purpose of this website is to demonstrate any projects that 
                    I have worked on or am currently working on. As time goes on, more 
                    projects will be added while I'm still in school. After I graduate I 
                    will be reorganizing the website to be centered around my skills and 
                    projects.<br><br></h3>
                </dd>
                <dt><h1>The Plan</h1></dt>
                <dd>
                    <h3>This page will contain a dropdown menu for each one of the senior 
                    classes. Each class will be added as term starts and each homework section 
                    will be added every week.<br><br> </h3>
                </dd>
                <dt><h1>Homework Page Layout</h1></dt>
                <dd>
                    <h3>All homework main pages will have a similar style for consistancy 
                    in design. Subpages from each homework page may have different layouts 
                    depending on requirements.<br> </h3>
                </dd>
            </dl>
        </div>
    </div>
</div>
    
    
```


#### I used a single column layout with an ordered list for my Git reference page.
[Git Page](https://goo.gl/huAzXL)

```html
<row>
    <col-md-8>
        <ol type="I">
            <li>
                <h1>Create Folder and Initialize</h1>
                <h3>First we need to create a folder, we'll call this folder "gitTutorial".
                    Then we need to initialize the folder to become a git repository 
                    with the command "git init".</h3>
            </li>
            <li>
                <h1>Adding, Commiting, and Pushing File</h1>
                <h3>After adding files to the repo, we can start commiting these filesize
                and pushing them to the repository.</h3>
                        
                <pre class="highlight">
                    <code>
                        git add tempFile.html
                        git commit -m "enter message here"
                        git push -u origin master
                    </code>
                </pre>
                <h3>Then after executing <code>git push -u origin master</code> git 
                will ask for the username and password. Enter your username and password 
                to push to the repository. If the user.name and user.email isn't set up, 
                git will ask you to set them up. It will also let you know how to do so.</h3>
            </li>
            <li>
                <h1>Fetching a Branch</h1>
                <h3>After pushing a repo you migh want to fetch it from another machine. 
                Fetching is a safer alternative to "pulling" a branch because when you 
                fetch a branch, you don't merge the two branches right away. If you pull 
                a branch then it will automatically merge everything for you and you might not
                want that. To fetch a branch and merge it with the master do the following: </h3>
                <pre>
                    <code>
                        git fetch origin
                        git merge origin/master
                    </code>
                </pre>
            </li>
        </ol>
    </col-md-8>
</row>

```


### This part demonstrates the use of CSS code, it's my root css file for the website.
[CSS File](https://goo.gl/hRyLHd)

```css
body {
    font-family: -apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif;
}

.refPages {
    text-align: center;
    color: #202020;
}

.refPages h1 {
    font-size: 80px;
    font-weight: 700;
}

.refPages h3 {
    font-size: 28px;
    line-height: 30px;
    font-weight: 400;
}

.contentFont {
    margin-top: 20px;
}

.contentFont h1 {
    color: #202020;
    font-size: 24px;
    font-weight: 700;
}

.contentFont h3 {
    color: #202020;
    font-size: 16px;
    line-height: 20px;
    font-weight: 400;
}

.contentFont li {
    font-size: 20px;
}

/*table style*/
.myTable {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    padding: 12px;
    text-align: left;
}

th {
    background-color: #414dd8;
    color: white;
}

tr:nth-child(even) {
    background-color: #f2f2f2
}

#homeScreenTable {
    
}


```

### I used a table in the landing page to keep track of my work.
[Landing Page](https://goo.gl/CynbUB)

```html
<div class="row">
    <div class="col-md-12">
        <h1>Work Done So Far</h1>
        <h3>The following table will keep track of the work I have done so far.</h3>
        <div class="myTable" id="homeScreenTable">
            <table style="width:100%">
                <tr>
                    <th>Homework #</th>
                    <th>Completion %</th>
                    <th>Chapter of DAD</th>
                    <th>Chapter Pro .Net MVC 5</th>
                </tr>
                <tr>
                    <td>Homework 1</td>
                    <td>70</td>
                    <td>1 Complete</td>
                    <td>1 Not Complete</td>
                </tr></tr>
            </table>
        </div>
    </div>
</div>

```

### I used three types of lists like ul, ol, and dl. I used an ol in the Git reference page and a ul in the navbar. The dl is in the landing page.
[Landing Page](https://goo.gl/CynbUB)
[Git Page](https://goo.gl/huAzXL)

```html
<dl>
    <dt><h1>Website Purpose</h1></dt>
    <dd>
        <h3>The purpose of this website is to demonstrate any projects that 
        I have worked on or am currently working on. As time goes on, more 
        projects will be added while I'm still in school. After I graduate I 
        will be reorganizing the website to be centered around my skills and 
        projects.<br><br></h3>
    </dd>
    <dt><h1>The Plan</h1></dt>
    <dd>
        <h3>This page will contain a dropdown menu for each one of the senior 
        classes. Each class will be added as term starts and each homework section 
        will be added every week.<br><br> </h3>
    </dd>
    <dt><h1>Homework Page Layout</h1></dt>
    <dd>
        <h3>All homework main pages will have a similar style for consistancy 
        in design. Subpages from each homework page may have different layouts 
        depending on requirements.<br> </h3>
    </dd>
</dl>

```


