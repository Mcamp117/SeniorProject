# EagleConnect - USI Alumni & Student Networking Platform

EagleConnect is a comprehensive networking platform designed to connect University of Southern Indiana (USI) students, alumni, faculty, and external mentors. The platform facilitates career development, mentorship opportunities, and professional networking within the USI community.

## 🚀 Features

### Core Functionality

#### 🔐 Authentication & Authorization
- **Role-based access control** with Admin, Student, Alumni, Faculty, and External user types
- Secure authentication using ASP.NET Core Identity
- Email confirmation and password reset functionality
- Profile management with custom user information

#### 👥 User Management
- **User Profiles**: Comprehensive profiles with bio, skills, job title, company, and graduation year
- **Skills System**: Add, remove, and manage skills with proficiency levels
- **Profile Images**: Upload and manage profile pictures (PNG format)
- **User Directory**: Browse and search users by type, skills, and keywords

#### 🔗 Connection & Messaging System
- **Connection Requests**: Send and receive connection requests between users
- **Real-time Chat**: SignalR-powered instant messaging between connected users
- **Connection Management**: Accept, decline, or view pending connection requests
- **Chat Interface**: Modern chat UI with message history and read receipts

#### 📝 Posting System
- **Connection Posts**: Create posts for networking, mentorship, and collaboration
- **Post Types**: Support for different post categories (Connection, Mentorship, etc.)
- **Post Management**: View, create, edit, and manage your posts
- **Cross-posting**: Posts automatically appear in relevant sections

#### 🎓 Mentorship Program
- **Mentorship Posts**: Alumni, Faculty, and External mentors can create mentorship opportunities
- **Filtered Views**: 
  - `/Alumni/Mentorship` - Shows only Alumni mentorship posts
  - `/External` - Shows only External mentor posts
  - `/Posts` - Shows all posts including Faculty mentorship posts
- **Mentorship Matching**: Connect students with experienced mentors

#### 🏢 Alumni & Networking
- **Alumni Directory**: Combined directory and networking page
- **Industry Filtering**: Browse alumni by industry and company
- **Connection Integration**: Connect/Chat buttons on all alumni profiles
- **Networking Statistics**: View network size, active mentorships, and industry distribution

#### 🏛️ Student Organizations
- **Organization Management**: Create and manage student organizations
- **Member Management**: Add/remove members from organizations
- **Organization Profiles**: View organization details and members

#### 👨‍💼 Admin Panel
- **User Management**: Full CRUD operations for user accounts
- **Role Management**: Assign and remove roles (Admin, User)
- **Skills Management**: Create and manage skills database
- **Organization Administration**: Manage student organizations
- **Relationship Management**: View and manage mentorship relationships
- **Post Moderation**: Manage all connection posts

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 8.0 (Razor Pages)
- **Database**: MySQL (via Pomelo.EntityFrameworkCore.MySql)
- **Real-time Communication**: SignalR
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Bootstrap 5, Font Awesome, jQuery
- **ORM**: Entity Framework Core

## 📁 Project Structure

```
EagleConnect/
├── Data/                    # Database context and configuration
├── Hubs/                    # SignalR hubs (ChatHub)
├── Models/                  # Data models (User, Connection, Message, etc.)
├── Pages/                   # Razor Pages
│   ├── Account/            # Authentication pages
│   ├── Admin/              # Admin panel pages
│   ├── Alumni/             # Alumni-specific pages
│   ├── External/           # External mentor pages
│   ├── Posts/              # Post management pages
│   └── Connections.cshtml  # Connections and chat page
├── Services/               # Business logic services
├── Migrations/             # EF Core database migrations
├── wwwroot/                # Static files (CSS, JS, images)
└── Program.cs              # Application entry point
```

## 🔧 Key Services

### ConnectionService
- Manage user connections (create, accept, decline)
- Check connection status between users
- Retrieve user connections and pending requests

### MessageService
- Send and receive messages
- Mark messages as read
- Get message history with pagination
- Track unread message counts

### UserService
- User CRUD operations
- User search and filtering
- Role management
- Skills management

### ConnectionPostService
- Create and manage connection posts
- Filter posts by type and status
- Post search functionality

## 🗄️ Database Models

### Core Models
- **ApplicationUser**: Extended Identity user with custom fields (Year, Company, JobTitle, Bio, etc.)
- **Connection**: Manages user connections with status (Pending, Accepted, Declined)
- **Message**: Chat messages between connected users
- **ConnectionPost**: User-created posts for networking and mentorship
- **Skill**: Skills database
- **UserSkill**: User-skill relationships with proficiency levels
- **Relationship**: Formal mentorship relationships
- **StudentOrganization**: Student organizations

## 🚦 Getting Started

### Prerequisites
- .NET 8.0 SDK
- MySQL Server
- Visual Studio 2022 or VS Code (recommended)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd EagleConnect
   ```

2. **Configure Database**
   - Update `appsettings.json` with your MySQL connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=EagleConnect;User=root;Password=yourpassword;"
     }
   }
   ```

3. **Run Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the Application**
   - Navigate to `http://localhost:5000` (or port shown in console)
   - Register a new account or log in

## 🔐 Default Roles

- **Admin**: Full system access
- **User**: Standard user access
- **Student**: Student-specific features
- **Alumni**: Alumni-specific features
- **Faculty**: Faculty-specific features
- **External**: External mentor features

## 📱 Key Pages & Routes

- `/` - Home page
- `/Account/Login` - Login page
- `/Account/Register` - Registration
- `/Account/Profile` - User profile management
- `/People` - Browse all users
- `/Connections` - Connections and chat interface
- `/Posts` - View all posts
- `/Posts/Create` - Create new post
- `/Alumni/Index` - Alumni directory & networking
- `/Alumni/Mentorship` - Alumni mentorship program
- `/External` - External mentors
- `/Admin/*` - Admin panel (requires Admin role)

## 🔄 Recent Updates

### Connection & Messaging System
- ✅ Real-time chat using SignalR
- ✅ Connection request system
- ✅ Connection status tracking
- ✅ Chat interface with message history
- ✅ Unread message indicators

### Mentorship System
- ✅ Mentorship post creation (Alumni, Faculty, External)
- ✅ Filtered mentorship views by user type
- ✅ Cross-posting to multiple pages
- ✅ Connection integration on posts

### User Experience Improvements
- ✅ Profile image upload (PNG support)
- ✅ Optional field validation fixes
- ✅ Connect/Chat button integration across pages
- ✅ TempData cleanup on logout
- ✅ Null reference warnings fixed

### Code Quality
- ✅ Proper null handling throughout codebase
- ✅ Comprehensive error handling
- ✅ Clean separation of concerns
- ✅ Service-based architecture

## 🧪 Testing

To test the application:

1. **Create Test Users**
   - Register as different user types (Student, Alumni, Faculty, External)
   - Assign Admin role via Admin panel if needed

2. **Test Connections**
   - Send connection requests between users
   - Accept/decline requests
   - Test real-time messaging

3. **Test Posts**
   - Create connection posts
   - Create mentorship posts (as Alumni/Faculty/External)
   - Verify filtering on different pages

## 📝 License

This project is part of a Senior Project for the University of Southern Indiana.

## 👥 Contributors

- USI Senior Project Team

## 📞 Support

For issues or questions, please contact the development team or create an issue in the repository.

---

**Built with ❤️ for the USI Community**
