import { 
  Shield, KeyRound, Lock, Zap, Users, 
  User, Settings, ShoppingCart, FileText, Database, Tag 
} from 'lucide-react';

export const Icons = {
  shield: <Shield size={16} className="text-gray-500" />,
  'user-key': <KeyRound size={16} className="text-gray-500" />,
  lock: <Lock size={16} className="text-gray-500" />,
  lightning: <Zap size={16} className="text-gray-500" />,
  users: <Users size={16} className="text-gray-500" />,
  user: <User size={16} className="text-gray-500" />,
  gear: <Settings size={16} className="text-gray-500" />,
  cart: <ShoppingCart size={16} className="text-gray-500" />,
  document: <FileText size={16} className="text-gray-500" />,
  database: <Database size={16} className="text-gray-500" />,
  tag: <Tag size={16} className="text-gray-500" />
};